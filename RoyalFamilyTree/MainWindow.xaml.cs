using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace RoyalFamilyTree
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadFamilyTree();
        }

        private void LoadFamilyTree()
        {
            var root = FamilyTreeData.GetWindsorFamilyTree();
            TreePanel.Children.Clear();
            RenderFamilyMember(root, TreePanel, 0);
        }

        private void RenderFamilyMember(FamilyMember member, Panel parent, int level)
        {
            // Create a border for the family member
            var border = new Border
            {
                Background = new SolidColorBrush(member.IsAlive ? Color.FromRgb(46, 204, 113) : Color.FromRgb(149, 165, 166)),
                CornerRadius = new CornerRadius(5),
                Padding = new Thickness(10),
                Margin = new Thickness(level * 30, 5, 0, 5),
                BorderBrush = new SolidColorBrush(Color.FromRgb(52, 73, 94)),
                BorderThickness = new Thickness(2)
            };

            var stackPanel = new StackPanel();

            // Name
            var nameText = new TextBlock
            {
                Text = member.Name,
                FontSize = 14,
                FontWeight = FontWeights.Bold,
                Foreground = Brushes.White
            };
            stackPanel.Children.Add(nameText);

            // Date of Birth
            var dobText = new TextBlock
            {
                Text = $"Born: {member.DateOfBirth:MMMM d, yyyy}",
                FontSize = 11,
                Foreground = new SolidColorBrush(Color.FromRgb(236, 240, 241)),
                Margin = new Thickness(0, 3, 0, 0)
            };
            stackPanel.Children.Add(dobText);

            // Status
            var statusText = new TextBlock
            {
                Text = member.GetStatusText(),
                FontSize = 11,
                FontStyle = FontStyles.Italic,
                Foreground = new SolidColorBrush(Color.FromRgb(236, 240, 241))
            };
            stackPanel.Children.Add(statusText);

            border.Child = stackPanel;
            parent.Children.Add(border);

            // Add spouse if exists
            if (member.Spouse != null && !AlreadyRendered(member.Spouse, parent))
            {
                var spouseBorder = new Border
                {
                    Background = new SolidColorBrush(member.Spouse.IsAlive ? Color.FromRgb(52, 152, 219) : Color.FromRgb(127, 140, 141)),
                    CornerRadius = new CornerRadius(5),
                    Padding = new Thickness(10),
                    Margin = new Thickness(level * 30, 5, 0, 5),
                    BorderBrush = new SolidColorBrush(Color.FromRgb(52, 73, 94)),
                    BorderThickness = new Thickness(2)
                };

                var spouseStack = new StackPanel();

                var spouseNameText = new TextBlock
                {
                    Text = $"m. {member.Spouse.Name}",
                    FontSize = 13,
                    FontWeight = FontWeights.SemiBold,
                    Foreground = Brushes.White
                };
                spouseStack.Children.Add(spouseNameText);

                var spouseDobText = new TextBlock
                {
                    Text = $"Born: {member.Spouse.DateOfBirth:MMMM d, yyyy}",
                    FontSize = 10,
                    Foreground = new SolidColorBrush(Color.FromRgb(236, 240, 241)),
                    Margin = new Thickness(0, 3, 0, 0)
                };
                spouseStack.Children.Add(spouseDobText);

                var spouseStatusText = new TextBlock
                {
                    Text = member.Spouse.GetStatusText(),
                    FontSize = 10,
                    FontStyle = FontStyles.Italic,
                    Foreground = new SolidColorBrush(Color.FromRgb(236, 240, 241))
                };
                spouseStack.Children.Add(spouseStatusText);

                spouseBorder.Child = spouseStack;
                parent.Children.Add(spouseBorder);
            }

            // Render children
            foreach (var child in member.Children)
            {
                RenderFamilyMember(child, parent, level + 1);
            }
        }

        private bool AlreadyRendered(FamilyMember member, Panel parent)
        {
            // Simple check to avoid rendering spouse twice
            foreach (var child in parent.Children)
            {
                if (child is Border border && border.Child is StackPanel stack)
                {
                    foreach (var element in stack.Children)
                    {
                        if (element is TextBlock text && (text.Text == member.Name || text.Text == $"m. {member.Name}"))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
