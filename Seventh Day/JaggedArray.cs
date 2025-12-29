class JA
{
    public void JArr()
    {
        int [][] JA=new int[3][];
        JA[0]=new int[]{1,2};
        JA[1]=new int[]{4,5,6};
        JA[2]=new int[]{7,8,9};
        for(int i = 0; i < JA.Length; i++)
        {
            for(int j = 0; j < JA[i].Length; j++)
            {
                Console.Write($"{JA[i][j]} ");
            }
            Console.WriteLine();
        }
    }
}