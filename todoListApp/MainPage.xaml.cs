using System.Diagnostics;
using System.Xml.Serialization;

namespace todoListApp
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            // Placeholder
        }

        private void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            // Placeholder
        }

        private void OnEntryCompleted(object sender, EventArgs e)
        {
            generateTask(enterTask.Text);

            enterTask.Text = string.Empty; // Clear entry
        }

        int taskId = 1;

        private void generateTask(string task)
        {
            var taskLayout = new HorizontalStackLayout
            {
                Spacing = 2,
                Margin = new Thickness(0, 15),
                HorizontalOptions = LayoutOptions.Start
            };

            // Generate checkbox with unique taskId
            var newCheckBox = new CheckBox
            {
                AutomationId = $"newCheckbox{taskId}",
                IsChecked = false
            };
            newCheckBox.CheckedChanged += OnCheckBoxCheckedChanged;

            // Generate label with unique taskId
            var newLabel = new Label
            {
                AutomationId = $"newLabel{taskId}",
                Text = task,
                BackgroundColor = Colors.LightGray,
                TextColor = Colors.Black,
                Padding = new Thickness(10),
                Margin = new Thickness(5, 0), 
            };

            var labelFrame = new Frame
            {
                AutomationId = $"frame{taskId}",
                Content = newLabel,
                BackgroundColor = Colors.LightGray,
                CornerRadius = 10, 
                Padding = 0, 
                Margin = new Thickness(5, 0), 
                HasShadow = false 
            };

            taskLayout.Children.Add(newCheckBox);
            taskLayout.Children.Add(labelFrame);

            taskContainer.Children.Add(taskLayout);

            taskId++; // Increase by one
        }


        private void ClearButtonClicked(object sender, EventArgs e)
        {
            taskContainer.Children.Clear();
        }
    }
}
