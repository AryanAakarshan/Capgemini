class MultidimentionalArray
{
    public  void MDA()
    {
        int[,] MDA={{1,2,3},{4,5,6}};
        for(int i = 0; i < MDA.GetLength(0); i++)
        {
            for(int j = 0; j < MDA.GetLength(1); j++)
            {
                Console.Write($"{MDA[i,j]}"+" ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}