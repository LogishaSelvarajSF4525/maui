namespace Maui.Controls.Sample
{
    public class BindableLayoutTestItem
    {
        public string Caption { get; set; }
        public int Index { get; set; }

        public BindableLayoutTestItem(string caption, int index)
        {
            Caption = caption;
            Index = index;
        }
    }
}
