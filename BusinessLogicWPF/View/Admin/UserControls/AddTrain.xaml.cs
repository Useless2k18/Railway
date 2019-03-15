// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddTrain.xaml.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Interaction logic for AddTrains.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BusinessLogicWPF.View.Admin.UserControls
{
    using System;
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Media;

    using BusinessLogicWPF.Annotations;
    using BusinessLogicWPF.Domain.TreeView;
    using BusinessLogicWPF.View.Helpers.UserControls;
    using BusinessLogicWPF.ViewModel.Admin;
    using BusinessLogicWPF.ViewModel.Admin.ForHelpers;

    using MaterialDesignThemes.Wpf;

    /// <summary>
    /// Interaction logic for AddTrains.XAML
    /// </summary>
    public partial class AddTrain : UserControl
    {
        /// <summary>
        /// The default margin.
        /// </summary>
        private readonly Thickness defaultMargin = default(Thickness);

        /// <summary>
        /// The current selected item.
        /// </summary>
        [CanBeNull]
        private string currentSelectedItem = string.Empty;

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:BusinessLogicWPF.View.Admin.UserControls.AddTrain" /> class.
        /// </summary>
        public AddTrain()
        {
            this.InitializeComponent();

            var addTrainViewModel = new AddTrainViewModel();

            // Root version (bind to RootNodeViewModelList with one item: RootNodeViewModel)
            var rootTreeView = this.BuildTreeView();
            var uiElement = rootTreeView;
            if (uiElement != null)
            {
                uiElement.ItemsSource = addTrainViewModel.RootNodeViewModelList;
                uiElement.SelectedItemChanged += this.TreeViewSelectedItemChanged;
                this.Grid2.Children.Add(uiElement);
                Grid.SetColumn(uiElement, 0);
            }
        }

        /// <summary>
        /// The view model.
        /// </summary>
        [CanBeNull]
        public AddTrainViewModel ViewModel => this.DataContext as AddTrainViewModel;

        /// <summary>
        /// Trees View's Selected Item is read-only. Hence we can't bind it. There is a way to obtain a selected item.
        /// </summary>
        /// <param name="sender">
        /// The sender
        /// </param>
        /// <param name="e">
        /// The Routed Property Changed Event Args
        /// </param>
        private void TreeViewSelectedItemChanged([CanBeNull] object sender, [CanBeNull] RoutedPropertyChangedEventArgs<object> e)
        {
            if (this.ViewModel == null)
            {
                return;
            }

            if (e != null)
            {
                // this.ViewModel.SelectedItem = e.NewValue;
                this.currentSelectedItem = ((NodeViewModel)e.NewValue).Name;
            }
        }

        /// <summary>
        /// The button add on click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private async void ButtonAddOnClick([CanBeNull] object sender, [CanBeNull] RoutedEventArgs e)
        {
            var list = new List<string>
                           {
                               "Chair Car",
                               "Second Sitting",
                               "First Tier AC",
                               "Second Tier AC",
                               "Third Tier AC",
                               "Sleeper"
                           };

            try
            {
                if (string.Compare(this.currentSelectedItem, "Coach", StringComparison.Ordinal) == 0)
                {
                    var dialog1 = new SelectionDialog { DataContext = new SelectCoachCategoryViewModel() };

                    var result1 = await DialogHost.Show(dialog1, "RootDialog", this.ClosingEventHandler)
                                      .ConfigureAwait(false);
                }
                else if (list.Contains(this.currentSelectedItem))
                {
                    var dialog2 = new SelectionDialog { DataContext = new EnterCoachesViewModel() };

                    var result2 = await DialogHost.Show(dialog2, "RootDialog", this.ClosingEventHandler)
                                      .ConfigureAwait(false);
                }
                else
                {
                    MessageBox.Show("Invalid request!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// The closing event handler.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="eventArgs">
        /// The event args.
        /// </param>
        private void ClosingEventHandler([CanBeNull] object sender, [CanBeNull] DialogClosingEventArgs eventArgs)
        {
        }

        /// <summary>
        /// Build a TreeView with multiple HierarchicalDataTemplates.
        /// I have built only root and 3 levels, but more levels can be extended.
        /// </summary>        
        private TreeView BuildTreeView()
        {
            HierarchicalDataTemplate levelNodeDefaultDataTemplate = this.BuildLevelNodeDataTemplate();
            HierarchicalDataTemplate rootNodeDataTemplate = this.BuildLevelNodeDataTemplate(0);
            HierarchicalDataTemplate level1NodeDataTemplate = this.BuildLevelNodeDataTemplate(1);
            HierarchicalDataTemplate level2NodeDataTemplate = this.BuildLevelNodeDataTemplate(2);
            HierarchicalDataTemplate level3NodeDataTemplate = this.BuildLevelNodeDataTemplate(3);
            var levelNodeDataTemplateList = new List<Tuple<int, HierarchicalDataTemplate>>
            {
                new Tuple<int, HierarchicalDataTemplate>(0, rootNodeDataTemplate),
                new Tuple<int, HierarchicalDataTemplate>(1, level1NodeDataTemplate),
                new Tuple<int, HierarchicalDataTemplate>(2, level2NodeDataTemplate),
                new Tuple<int, HierarchicalDataTemplate>(3, level3NodeDataTemplate),
            };

            var treeView = new TreeView
                               {
                                   ItemTemplateSelector = new NodeDataTemplateSelector(levelNodeDefaultDataTemplate, levelNodeDataTemplateList)
                               };

            // Disable selection highlight
            treeView.Resources.Add(SystemColors.HighlightBrushKey, new SolidColorBrush(Colors.Transparent));
            treeView.Resources.Add(SystemColors.HighlightTextBrushKey, new SolidColorBrush(Colors.Black));
            treeView.Resources.Add(SystemColors.InactiveSelectionHighlightBrushKey, new SolidColorBrush(Colors.Transparent));
            treeView.Resources.Add(SystemColors.InactiveSelectionHighlightTextBrushKey, new SolidColorBrush(Colors.Black));

            return treeView;
        }

        private HierarchicalDataTemplate BuildLevelNodeDataTemplate(int level = int.MaxValue)
        {
            FrameworkElementFactory levelNodeElementFactory;
            switch (level)
            {
                case 0: levelNodeElementFactory = this.BuildRootNodeVisual(); break;
                case 1: levelNodeElementFactory = this.BuildLevel1NodeVisual(); break;
                case 2: levelNodeElementFactory = this.BuildLevel2NodeVisual(); break;
                case 3: levelNodeElementFactory = this.BuildLevel3NodeVisual(); break;
                default: levelNodeElementFactory = this.BuildLevelNodeBasicVisual(); break;
            }

            var levelNodeDataTemplate = new HierarchicalDataTemplate
                                            {
                                                ItemsSource = new Binding("ChildNodes"),
                                                VisualTree = levelNodeElementFactory
                                            };
            return levelNodeDataTemplate;
        }

        private FrameworkElementFactory BuildRootNodeVisual()
        {
            return this.BuildLevelNodeBasicVisual(nameFontBold: true);
        }

        private FrameworkElementFactory BuildLevel1NodeVisual()
        {
            var stackPanelFactory = this.CreateStackPanelFactory(
                    Orientation.Horizontal, new Thickness(4, 4, 5, 2));
            var textBlockFactory = new FrameworkElementFactory(typeof(TextBlock));
            textBlockFactory.SetBinding(TextBlock.TextProperty, new Binding("Name"));
            textBlockFactory.SetValue(TextBlock.FontWeightProperty, FontWeights.Bold);
            textBlockFactory.SetValue(TextBlock.TextDecorationsProperty, TextDecorations.Underline);
            textBlockFactory.SetValue(MarginProperty, new Thickness(0, 3, 0, 0));
            stackPanelFactory.AppendChild(textBlockFactory);

            return stackPanelFactory;
        }

        private FrameworkElementFactory BuildLevel2NodeVisual()
        {
            var stackPanelFactory = this.CreateStackPanelFactory(Orientation.Horizontal, new Thickness(4, 4, 5, 2));
            this.AppendTextBlockBinding(stackPanelFactory, "Name");

            // Bind SearchImagePath with Level2NodeViewModel
            return stackPanelFactory;
        }

        /// <summary>
        /// Level 3 node: horizontal stack panel containing an image 
        /// and a vertical statck panel containing Name, Author, and Hyperlink        
        /// </summary>        
        private FrameworkElementFactory BuildLevel3NodeVisual()
        {
            var stackPanelFactory = this.CreateStackPanelFactory(Orientation.Horizontal, new Thickness(0, 0, 0, 4));
            var stackPanelFactoryVert = this.CreateStackPanelFactory(Orientation.Vertical, new Thickness(4, 4, 5, 2));
            this.AppendTextBlockBinding(stackPanelFactoryVert, "Name", textFontBold: true);
            this.AppendTextBlockBinding(stackPanelFactoryVert, "Author");
            stackPanelFactory.AppendChild(stackPanelFactoryVert);
            return stackPanelFactory;
        }

        private FrameworkElementFactory BuildLevelNodeBasicVisual(bool nameFontBold = false)
        {
            var stackPanelFactory = this.CreateStackPanelFactory(Orientation.Horizontal, new Thickness(4, 4, 5, 2));
            this.AppendTextBlockBinding(stackPanelFactory, "Name", nameFontBold);
            return stackPanelFactory;
        }

        private StackPanel BuildRootlessHeaderVisual(string headerText, string imagePath)
        {
            var stackPanel = this.CreateStackPanel(Orientation.Horizontal, new Thickness(4, 5, 5, 2));

            // TextBlock inside StackPanel
            var textBlock = new TextBlock();
            textBlock.SetValue(TextBlock.TextProperty, headerText);
            textBlock.SetValue(MarginProperty, new Thickness(0, 2, 0, 0));
            textBlock.SetValue(TextBlock.FontWeightProperty, FontWeights.Bold);
            textBlock.SetValue(TextBlock.FontStyleProperty, FontStyles.Italic);
            stackPanel.Children.Add(textBlock);

            return stackPanel;
        }

        private FrameworkElementFactory CreateStackPanelFactory(
                    Orientation orientation = Orientation.Horizontal, Thickness margin = default(Thickness))
        {
            var stackPanelFactory = new FrameworkElementFactory(typeof(StackPanel));
            stackPanelFactory.SetValue(StackPanel.OrientationProperty, orientation);
            if (margin != this.defaultMargin)
            {
                stackPanelFactory.SetValue(MarginProperty, margin);
            }

            return stackPanelFactory;
        }

        private void AppendTextBlockBinding(FrameworkElementFactory container, string name, bool textFontBold = false)
        {
            var textBlockFactory = new FrameworkElementFactory(typeof(TextBlock));
            textBlockFactory.SetBinding(TextBlock.TextProperty, new Binding(name));
            if (textFontBold)
            {
                textBlockFactory.SetValue(TextBlock.FontWeightProperty, FontWeights.Bold);
            }

            container.AppendChild(textBlockFactory);
        }

        private StackPanel CreateStackPanel(
            Orientation orientation = Orientation.Horizontal, Thickness margin = default(Thickness))
        {
            var stackPanel = new StackPanel();
            stackPanel.SetValue(StackPanel.OrientationProperty, orientation);
            stackPanel.SetValue(HeightProperty, 20d);
            stackPanel.SetValue(VerticalAlignmentProperty, VerticalAlignment.Top);
            if (margin != this.defaultMargin)
            {
                stackPanel.SetValue(MarginProperty, margin);
            }

            return stackPanel;
        }
    }
}
