class RNJesus{
    public float getRange()
    {
        int range=Random.Range(6,11);
        return range/10;
    }
    public float crit()
    {
        float resp=1;
        int crit=Random.Range(1,11);
        if(crit>=9)
        {
            resp=2;
        }
        return resp;
        
    }
    public bool erraAcao(int precisao)
    {
        return Random.Range(1,101)>precisao;
    } 

}
