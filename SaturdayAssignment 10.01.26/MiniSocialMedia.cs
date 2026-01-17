using System.Linq.Expressions;
using System.Text;
using System.Text.Json;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MiniSocialMedia{
    public class PostTooLongException : Exception
    {
        public PostTooLongException(string message):base(message){}
    }
    class SocialException :Exception
    {
        public SocialException(string msg): base (msg)
        {
        }
        public SocialException(string message, Exception inner)
        : base(message, inner)
        {
        }

    }
    public interface IPostable
    {
        public void AddPost(string content);
        IReadOnlyList<Post> GetPosts();
    }
    class Post
    {
        public User Author {get;}
        public string Content{get;}
        public DateTime CreatedAt{get;}
        public Post(User author,string content,DateTime createdAt)
        {
            if(!String.IsNullOrWhiteSpace(Author))
            Author=author;
            else throw new ArgumentException();
            Content = content;
            CreatedAt = createdAt;
        }
        public override string ToString()
        {
            StringBuilder sb=new StringBuilder();
            sb.AppendLine($"{Author} . {CreatedAt:MMM dd HH:mm}");
            sb.AppendLine(Content);
            MatchCollection hashtags=Regex.Matches(Content,@"#[A-Za-z]+");
            if (hashtags.Count > 0)
        {
            sb.Append("Tags: ");
            sb.AppendJoin(", ", hashtags.Cast<Match>().Select(m => m.Value));
        }
        return sb.ToString().TrimEnd();

        }
    }
    public partial class User : IPostable, IComparable<User>
    {
        public string UserName{get;init;}
        public string Email{get;init;}
        private List<Post> _Posts=new();
        private HashSet<string> _following=new();
        public event Action<Post>? OnNewPost;
        public User(string username,string email)
        {
            if(!string.IsNullOrEmpty(username)){UserName=username;}
            else throw new SocialException("Invalid Username format");
            string pattern=@"^[\w.-]+@[\w.-]+\.\w{2,}$";
                bool valid=Regex.IsMatch(email,pattern);
                if (!valid)
                {
                    throw new SocialException("Invalid email format");
                }
                Email=email;
        }
        public void Follow(string username)
        {
            if (string.Equals(UserName, UserName, StringComparison.OrdinalIgnoreCase))
            {
                throw new SelfFollowException("Cannot follow yourself");
            }
            _following.Add(username);
            
        }
        public bool IsFollowing(string username)
        {
            return _following.Any(U=>string.Equals(U,username,StringComparison.OrdinalIgnoreCase));
        }
        public event Action OnNewPost
        {
            
        }
        public void AddPost(string content)
        {
            if (!string.IsNullOrEmpty(content))
            {
                if (content.Length() < 280)
                {
                    string cleanedContent=content.Trim();
                    Post newPost=new Post(this,cleanedContent);
                    _Posts.Add(newPost);
                    POstCreated?.Invoke(newPost);
                }
            }
            else throw new Exception(ArgumentException);
        }
        public IReadOnlyList<Post> GetPosts()
        {
            return _posts.AsReadOnly();
        }

        public IReadOnlyList<Post> GetPosts()
        {
            return _Posts.AsReadOnly();
        }
        public int CompareTo(User other)
        {
            if (other == null)
            {
                return 1;
            }
            return string.Compare(this.UserName,other.UserName,StringComparison.OrdinalIgnoreCase);
        }
        

        }
        public partial class User
    {
        public string GetDisplayName()
        {
            return $"User: {UserName} <{Email}>";
        }
    }

    public class Repository<T> where T : User
    {
        private readonly List<T> _items=new List<T>();
        public void Add(T item) =>_items.Add(item);
        public IReadOnlyList<T> GetAll() => _items.AsReadOnly();
        public T?  Find(Predicate<T> match) =>_items.Find(match);

    }
    public static class SocialUtils
    {
        public static string FormatTimeAge(this DateTime pastTime)
        {
            DateTime utc=DateTime.UtcNow;
            TimeSpan Diffrence=utc-pastTime;
            if (Diffrence.TotalMinutes < 1)
            {
                return "just now";
            }
            else if (Diffrence.TotalMinutes < 60)
            {
                return $"{Diffrence.TotalMinutes} min ago";
            }
            else if (Diffrence.TotalHours < 24)
            {
                return $"{Diffrence.TotalHours} h ago";
            }
            else
            {
                return $"{pastTime.ToString}";
            }

        }
    }
        

    class Program{


        public static Repository<User> _users=new  Repository<User>();
        public static User? _currentUser=null;
        public static  readonly string _dataFile = "social-data.json";


        static void Main()
        {

            // try
            // {
            //     Console.Write("Enter email: ");
            //     string email= Console.ReadLine();
            //     string pattern=@"^[\w.-]+@[\w.-]+\.\w{2,}$";
            //     bool valid=Regex.IsMatch(email,pattern);
            //     if (!valid)
            //     {
            //         throw new SocialException("Invalid email format");
            //     }
            //     Console.WriteLine("Email is valid");
            // }
            // catch(SocialException ex)
            // {
            //     Console.WriteLine("Email error: "+ex.Message);
            // }
            // catch (Exception ex)
            // {
            //     Console.WriteLine("General error: "+ ex.Message);
            // }


            Console.WriteLine("MiniSocial - Console Edition\nMiniSocial - Console Edition");
            LoadData();
            bool flag=true;
            while (flag)
            {
                if(_currentUser==null) ShowLoginMenu();
                else ShowMainMenu();
            }
        }
        public static void ShowLoginMenu()
        {
            int choice;
            Console.WriteLine("1.Register\n2.Login\n0.Exit");
            Console.Write("User input: ");
            choice=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            switch (choice)
            {
                case 1:
                Register();
                break;
                case 2:
                Login();
                break;
                case 0:
                SaveData();
                Environment.Exit(0);
                break;
                default:
                Console.WriteLine("Invalid menu choice.");
                break;
            }
        }
        public static void Register()
        {
            Console.WriteLine("Enter Username: ");
            string username = Console.ReadLine();
            Console.WriteLine("Enter Email: ");
            string Email = Console.ReadLine();
            if(string.IsNullOrWhiteSpace(username)||string.IsNullOrWhiteSpace(Email))
                throw new SocialException("Username and Email is required");
            var existing = _users.Find(u=>string.Equals(u.UserName,username,StringComparison.OrdinalIgnoreCase));
            if (existing != null)
            {
                throw new SocialException("UserName already exists.");
            }
            User newuser=new User(username,Email);
            _users.Add(newuser);
            Console.WriteLine($"Welcome {username} to mini social app");
        }
        public static void Login()
        {
            Console.WriteLine("Enter Username: ");
            string username = Console.ReadLine();
            var existing=_users.Find(u=>string.Equals(u.UserName,username,StringComparison.OrdinalIgnoreCase));
            if (existing == null)
            {
                Console.WriteLine("UserName does not exists."); return;
            }
            _currentUser=User;
            Console.WriteLine($"Logged in as {_currentUser.Username}!");
            _currentUser.OnNewPost+=OnPostNotification;
        }

        public static void ShowMainMenu()
        {
            Console.Write("1.Post message\n2.View my posts\n3.View timeline(feed)\n4.Follow user\n5.List users\n6.Logout\n0.Exit and save");
            Console.WriteLine("\nUserChoice: ");
            int chose=Convert.ToInt32(Console.ReadLine());
            switch (chose)
            {
                case 1: postMessage();break;
                case 2: ShowPost(_currentUser.GetPosts());break;
                case 3: ShowTimeLine();break;
                case 4: followUser();break;
                case 5: listUsers();break;
                case 6: _currentUser=null;Console.WriteLine("Logged out.");break;
                case 0: SaveData();Environment.Exit(0);break;
                default: Console.WriteLine("Invalid Input"); break;
            }
        }
        public static void postMessage()
        {
            if(_currentUser==null)return;
            Console.WriteLine("Enter your Post(Maximum 280 charactes): ");
            string post=Console.ReadLine();
            if (string.IsNullOrWhiteSpace(Content))
            {
                Console.WriteLine("Post cancelled.");
                return;
            }
            _currentUser.AddPost(post);
            Console.WriteLine("Post created successfully for "+_currentUser.UserName);
        }
        public static void ShowTimeLine()
        {
            if(_currentUser==null) return;
            List<Post> timeLine=new();
            timeLine.AddRange(_currentUser.GetPosts);
            foreach(var name in _currentUser.GetFollowingName)
            {
                var match= _users.Find(u=>string.Equals(u.UserName,name.StringComparison.OrdinalIgnoreCase));
                if (match != null)
                {
                    timeLine.AddRange(Users.GetPosts());
                }
                var sorted=timeLine.OrderByDescending(p=>p.CreatedAt).ToList();
                Console.WriteLine("\n=== Your Timeline ===");
                ShowPosts(sorted);
            }
        }
        public static void ShowPosts(IEnumerable<Post> posts)
        {
            if (_currentUser == null)
                return;
            int count =0;
            bool shown=false;
            foreach(var post in posts)
            {
                if(count>=20) break;
                Console.WriteLine(post);
                Console.WriteLine(post.CreatedAt.FormatTimeAge());
                Console.WriteLine("-----------------------------");
                count++;
                shown=true;
            }
            if(!shown)Console.WriteLine("No posts yet.");

        }
        private static void followUser()
        {
            if (_currentUser == null)
                return;
            Console.WriteLine("Enter usernameto follow: ");
            string person=Console.ReadLine();
            if (string.IsNullOrWhiteSpace(person))
            {
                Console.WriteLine("Cancelled.");
                return;
            }
            if (string.Equals(person, _currentUser.UserName, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("You cannot follow yourself.");
                return;

            }
            var user=_users.Find(u=>string.Equals(u.UserName,person,StringComparison.OrdinalIgnoreCase));
            if (user == null)
            {
                Console.WriteLine("User not found.");
                return;
            }
            _currentUser.Follow(person);
            Console.WriteLine("Now following @"+person);

        }
        public static void listUsers()
        {
            Console.WriteLine("Registered Users:");
            var sorted=_users.GetAll().OrderBy(u=>u.UserName,StringComparer.OrdinalIgnoreCase);
            foreach(var user in sorted)
            {
                Console.WriteLine($"{user,-20} {user.Email}");
            }
        }

        public static void SaveData()
        {
            try
            {
                var data = _users.GetAll().Select(u => new
                {
                    u.UserName,u.Email,Following=u.GetFollowingNames().ToList(),
                    Posts=u.GetPosts.Select(p=> new
                    {
                        p.Content,p.CreatedAt
                    }).ToList()
                }).ToList();
                string json = JsonSerializer.Serialize(
                    data,
                    new JsonSerializerOptions{WriteIndented = true});
                    File.WriteAllText(_dataFile,json);
                    Console.WriteLine("Data saved");
            }
            catch(Exception ex)
            {
                LogError(ex);
                Console.WriteLine("Failed To save data.");
            }
        } 
        public static void LoadData()
        {
            try{
            if (_dataFile == string.Empty())
            {
                return;
            }
            string json=File.ReadAllText(_dataFile);
            if(string.IsNullOrWhiteSpace(json))return;
            Console.WriteLine("Dataloaded (simulation - add proper logic)");
            }catch(Exception ex)
            {
                LogError(ex);
                Console.WriteLine("Failed to load data.");
            }
        }
        private static void LogError(Exception ex)
        {
            try
            {
                string entry =
                    $"[{DateTime.Now}]\n" +
                    $"Message: {ex.Message}\n" +
                    $"StackTrace:\n{ex.StackTrace}\n" +
                    $"--------------------------\n";

                File.AppendAllText("error.log", entry);
            }
            catch
            {
                // Fail silently
            }
        }
        private static void OnPostNotification(Post post)
        {
            string preview = post.Content.Length > 40
            ? post.Content.Substring(0,40) + "..."
            : post.Content;
        }




    }
}