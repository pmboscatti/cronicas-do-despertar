class RNJesus{
    public static float getRange()
    {
        System.Random rd= new System.Random();
        int range=rd.Next(6,11);
        return range/10;
    }
    public static float crit()
    {
        float resp=1;
        System.Random rd= new System.Random();
        int crit=rd.Next(1,11);
        if(crit>=9)
        {
            resp=2;
        }
        return resp;
        
    }
    public static bool erraAcao(int precisao)
    {
        System.Random rd= new System.Random();
        return rd.Next(1,101)>precisao;
    } 

}