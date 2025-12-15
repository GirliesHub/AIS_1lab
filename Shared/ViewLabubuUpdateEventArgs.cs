using LabubuModel;

namespace Shared
{
    public class ViewLabubuUpdateEventArgs : EventArgs
    {
        public Labubu Labubu { get; }

        public ViewLabubuUpdateEventArgs(Labubu labubu)
        {
            Labubu = labubu;
        }
    }
}
