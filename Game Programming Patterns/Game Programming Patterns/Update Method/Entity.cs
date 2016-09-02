namespace Game_Programming_Patterns.Update_Method
{
    public interface Entity
    {
        double X { get; set; }

        double Y { get; set; }

        void Update();
    }
}
