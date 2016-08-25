namespace Game_Programming_Patterns.Observer
{
    public class Achievements : Observer
    {
        public Achievements(Subject subject)
        {
            subject.Notify += new OnNotify(Handle);
        }

        private void Handle(Event e)
        {
        }
    }
}
