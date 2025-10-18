using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace RoyalFamilyTree
{
    public partial class MainWindow : Window
    {
        private FamilyMember? _rootMember;
        private FamilyMember? _currentSearchResult;

        public MainWindow()
        {
            InitializeComponent();
            LoadFamilyTree();
        }

        private void LoadFamilyTree()
        {
            _rootMember = FamilyTreeData.GetWindsorFamilyTree();
            TreePanel.Children.Clear();
            RenderFamilyMember(_rootMember, TreePanel, 0);
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

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            if (_rootMember == null || string.IsNullOrWhiteSpace(SearchBox.Text))
            {
                MessageBox.Show("Please enter a search term.", "Search", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            var searchTerm = SearchBox.Text.Trim();
            var results = _rootMember.SearchAllByName(searchTerm);

            if (results.Count == 0)
            {
                MessageBox.Show($"No family members found matching '{searchTerm}'.", "Search Results", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (results.Count == 1)
            {
                ShowMemberDetails(results[0]);
            }
            else
            {
                // Multiple results - show selection dialog
                ShowMultipleResultsDialog(results);
            }
        }

        private void ShowMemberDetails(FamilyMember member)
        {
            _currentSearchResult = member;
            
            var position = member.GetSuccessionPosition(_rootMember!);
            var positionText = position > 0 ? $"Position in line to throne: #{position}" : "Not in direct line of succession";
            
            var details = $"Name: {member.Name}\n" +
                         $"Date of Birth: {member.DateOfBirth:MMMM d, yyyy}\n" +
                         $"Status: {member.GetStatusText()}\n" +
                         $"{positionText}\n";
            
            if (member.Spouse != null)
            {
                details += $"\nSpouse: {member.Spouse.Name}";
            }
            
            if (member.Children.Count > 0)
            {
                details += $"\nChildren: {member.Children.Count}";
            }

            MessageBox.Show(details, "Family Member Details", MessageBoxButton.OK, MessageBoxImage.Information);
            
            // Highlight the member in the tree
            HighlightMember(member);
        }

        private void ShowMultipleResultsDialog(System.Collections.Generic.List<FamilyMember> results)
        {
            var dialog = new Window
            {
                Title = "Multiple Results Found",
                Width = 400,
                Height = 300,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                Owner = this,
                Background = new SolidColorBrush(Color.FromRgb(236, 240, 241))
            };

            var panel = new StackPanel { Margin = new Thickness(20) };
            
            var title = new TextBlock
            {
                Text = $"Found {results.Count} members:",
                FontSize = 14,
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(0, 0, 0, 10)
            };
            panel.Children.Add(title);

            var listBox = new ListBox
            {
                Height = 150,
                Margin = new Thickness(0, 0, 0, 10)
            };

            foreach (var member in results)
            {
                listBox.Items.Add(new { Display = $"{member.Name} - Born {member.DateOfBirth:yyyy}", Member = member });
            }
            listBox.DisplayMemberPath = "Display";
            panel.Children.Add(listBox);

            var selectButton = new Button
            {
                Content = "View Details",
                Width = 100,
                Height = 30,
                Background = new SolidColorBrush(Color.FromRgb(52, 152, 219)),
                Foreground = Brushes.White,
                BorderThickness = new Thickness(0),
                FontWeight = FontWeights.Bold
            };
            selectButton.Click += (s, e) =>
            {
                if (listBox.SelectedItem != null)
                {
                    var selected = (dynamic)listBox.SelectedItem;
                    dialog.Close();
                    ShowMemberDetails(selected.Member);
                }
            };
            panel.Children.Add(selectButton);

            dialog.Content = panel;
            dialog.ShowDialog();
        }

        private void HighlightMember(FamilyMember member)
        {
            // Reload tree with highlight
            TreePanel.Children.Clear();
            RenderFamilyMemberWithHighlight(_rootMember!, TreePanel, 0, member);
        }

        private void RenderFamilyMemberWithHighlight(FamilyMember member, Panel parent, int level, FamilyMember highlight)
        {
            bool isHighlighted = member == highlight;
            
            // Create a border for the family member
            var border = new Border
            {
                Background = new SolidColorBrush(member.IsAlive ? Color.FromRgb(46, 204, 113) : Color.FromRgb(149, 165, 166)),
                CornerRadius = new CornerRadius(5),
                Padding = new Thickness(10),
                Margin = new Thickness(level * 30, 5, 0, 5),
                BorderBrush = isHighlighted ? new SolidColorBrush(Color.FromRgb(231, 76, 60)) : new SolidColorBrush(Color.FromRgb(52, 73, 94)),
                BorderThickness = isHighlighted ? new Thickness(4) : new Thickness(2)
            };

            var stackPanel = new StackPanel();

            // Name
            var nameText = new TextBlock
            {
                Text = member.Name + (isHighlighted ? " ⭐" : ""),
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
                bool spouseHighlighted = member.Spouse == highlight;
                
                var spouseBorder = new Border
                {
                    Background = new SolidColorBrush(member.Spouse.IsAlive ? Color.FromRgb(52, 152, 219) : Color.FromRgb(127, 140, 141)),
                    CornerRadius = new CornerRadius(5),
                    Padding = new Thickness(10),
                    Margin = new Thickness(level * 30, 5, 0, 5),
                    BorderBrush = spouseHighlighted ? new SolidColorBrush(Color.FromRgb(231, 76, 60)) : new SolidColorBrush(Color.FromRgb(52, 73, 94)),
                    BorderThickness = spouseHighlighted ? new Thickness(4) : new Thickness(2)
                };

                var spouseStack = new StackPanel();

                var spouseNameText = new TextBlock
                {
                    Text = $"m. {member.Spouse.Name}" + (spouseHighlighted ? " ⭐" : ""),
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
                RenderFamilyMemberWithHighlight(child, parent, level + 1, highlight);
            }
        }

        private void ClearSearchButton_Click(object sender, RoutedEventArgs e)
        {
            SearchBox.Text = "";
            _currentSearchResult = null;
            LoadFamilyTree();
        }

        private void AddMemberButton_Click(object sender, RoutedEventArgs e)
        {
            if (_rootMember == null)
                return;

            // Create add member dialog
            var dialog = new Window
            {
                Title = "Add Family Member",
                Width = 450,
                Height = 450,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                Owner = this,
                Background = new SolidColorBrush(Color.FromRgb(236, 240, 241))
            };

            var mainPanel = new StackPanel { Margin = new Thickness(20) };

            // Name
            mainPanel.Children.Add(new TextBlock { Text = "Name:", FontWeight = FontWeights.Bold, Margin = new Thickness(0, 0, 0, 5) });
            var nameBox = new TextBox { Height = 25, Margin = new Thickness(0, 0, 0, 10) };
            mainPanel.Children.Add(nameBox);

            // Date of Birth
            mainPanel.Children.Add(new TextBlock { Text = "Date of Birth:", FontWeight = FontWeights.Bold, Margin = new Thickness(0, 0, 0, 5) });
            var dobPicker = new DatePicker { Height = 25, Margin = new Thickness(0, 0, 0, 10), SelectedDate = DateTime.Now };
            mainPanel.Children.Add(dobPicker);

            // Is Alive
            var aliveCheckBox = new CheckBox { Content = "Currently Alive", IsChecked = true, Margin = new Thickness(0, 0, 0, 10) };
            mainPanel.Children.Add(aliveCheckBox);

            // Parent Selection
            mainPanel.Children.Add(new TextBlock { Text = "Select Parent:", FontWeight = FontWeights.Bold, Margin = new Thickness(0, 0, 0, 5) });
            var parentCombo = new ComboBox { Height = 25, Margin = new Thickness(0, 0, 0, 20) };
            
            // Populate parents (using BFS to get all members)
            var allMembers = _rootMember.BreadthFirstSearch();
            foreach (var member in allMembers)
            {
                parentCombo.Items.Add(new { Display = member.Name, Member = member });
            }
            parentCombo.DisplayMemberPath = "Display";
            if (parentCombo.Items.Count > 0)
                parentCombo.SelectedIndex = 0;
            mainPanel.Children.Add(parentCombo);

            // Buttons
            var buttonPanel = new StackPanel { Orientation = Orientation.Horizontal, HorizontalAlignment = HorizontalAlignment.Center };
            
            var addButton = new Button
            {
                Content = "Add",
                Width = 80,
                Height = 30,
                Margin = new Thickness(0, 0, 10, 0),
                Background = new SolidColorBrush(Color.FromRgb(39, 174, 96)),
                Foreground = Brushes.White,
                BorderThickness = new Thickness(0),
                FontWeight = FontWeights.Bold
            };
            addButton.Click += (s, ev) =>
            {
                if (string.IsNullOrWhiteSpace(nameBox.Text))
                {
                    MessageBox.Show("Please enter a name.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (parentCombo.SelectedItem == null)
                {
                    MessageBox.Show("Please select a parent.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var parent = ((dynamic)parentCombo.SelectedItem).Member as FamilyMember;
                var newMember = new FamilyMember(
                    nameBox.Text.Trim(),
                    dobPicker.SelectedDate ?? DateTime.Now,
                    aliveCheckBox.IsChecked ?? true
                );

                parent!.Children.Add(newMember);
                dialog.Close();
                LoadFamilyTree();
                MessageBox.Show($"{newMember.Name} has been added to the family tree!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            };

            var cancelButton = new Button
            {
                Content = "Cancel",
                Width = 80,
                Height = 30,
                Background = new SolidColorBrush(Color.FromRgb(149, 165, 166)),
                Foreground = Brushes.White,
                BorderThickness = new Thickness(0),
                FontWeight = FontWeights.Bold
            };
            cancelButton.Click += (s, ev) => dialog.Close();

            buttonPanel.Children.Add(addButton);
            buttonPanel.Children.Add(cancelButton);
            mainPanel.Children.Add(buttonPanel);

            dialog.Content = mainPanel;
            dialog.ShowDialog();
        }
    }
}
