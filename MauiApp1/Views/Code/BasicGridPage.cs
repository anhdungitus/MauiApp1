namespace MauiApp1.Views.Code
{
    public class BasicGridPage : ContentPage
    {
        public BasicGridPage()
        {
            Grid grid = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition(),
                    new RowDefinition()
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition()
                }
            };

            // Row 0
            // The BoxView and Label are in row 0 and column 0, and so only need to be added to the
            // Grid to obtain the default row and column settings.
            grid.Add(new BoxView
            {
                Color = Colors.Green
            });

            grid.Add(new Label
            {
                Text = "Bai hat",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            });

            // This BoxView and Label are in row 0 and column 1, which are specified as arguments
            // to the Add method. 
            grid.Add(new BoxView
            {
                Color = Colors.Blue
            }, 1, 0);
            grid.Add(new Label
            {
                Text = "Bai hat 1",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            }, 1, 0);

            // Row 1
            // This BoxView and Label are in row 1 and column 0, which are specified as arguments
            // to the Add method overload.
            grid.Add(new BoxView
            {
                Color = Colors.Teal
            }, 0, 1);
            grid.Add(new Label
            {
                Text = "Bai hat 2",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            }, 0, 1);

            // This BoxView and Label are in row 1 and column 1, which are specified as arguments
            // to the Add method overload.
            grid.Add(new BoxView
            {
                Color = Colors.Purple
            }, 1, 1);
            grid.Add(new Label
            {
                Text = "Bai hat 3",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            }, 1, 1);

            // Row 2
            // Alternatively, the BoxView and Label can be positioned in cells with the Grid.SetRow
            // and Grid.SetColumn methods.
            BoxView boxView = new BoxView { Color = Colors.Red };
            Grid.SetRow(boxView, 2);
            Grid.SetColumnSpan(boxView, 2);
            Label label = new Label
            {
                Text = "Bai hat 4",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            Grid.SetRow(label, 2);
            Grid.SetColumnSpan(label, 2);

            grid.Add(boxView);
            grid.Add(label);

            Title = "Music App";
            Content = grid;
        }
    }
}
