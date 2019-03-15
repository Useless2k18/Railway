// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NodeDataTemplateSelector.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Defines the NodeDataTemplateSelector type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BusinessLogicWPF.Domain.TreeView
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// The node data template selector.
    /// </summary>
    public class NodeDataTemplateSelector : DataTemplateSelector
    {
        private HierarchicalDataTemplate _defaultLevelNodeDataTemplate;
        private List<Tuple<int, HierarchicalDataTemplate>> _levelNodeDataTemplateList;

        public NodeDataTemplateSelector(
                HierarchicalDataTemplate defaultLevelNodeDataTemplate,
                    List<Tuple<int, HierarchicalDataTemplate>> levelNodeDataTemplateList)
        {
            this._defaultLevelNodeDataTemplate = defaultLevelNodeDataTemplate;
            this._levelNodeDataTemplateList = levelNodeDataTemplateList ?? new List<Tuple<int, HierarchicalDataTemplate>>();
        }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            DataTemplate dataTemplate;
            if (item == null)
                dataTemplate = base.SelectTemplate(null, container);
            else if (item is RootNodeViewModel)
                dataTemplate = this.LevelNodeDateTemplateOrDefault(0);
            else if (item is Level1NodeViewModel)
                dataTemplate = this.LevelNodeDateTemplateOrDefault(1);
            else if (item is Level2NodeViewModel)
                dataTemplate = this.LevelNodeDateTemplateOrDefault(2);
            else if (item is Level3NodeViewModel)
                dataTemplate = this.LevelNodeDateTemplateOrDefault(3);
            else
                dataTemplate = this._defaultLevelNodeDataTemplate;

            return dataTemplate;
        }

        private DataTemplate LevelNodeDateTemplateOrDefault(int level)
        {
            var levelDataTemplate = this._levelNodeDataTemplateList.FirstOrDefault(x => x.Item1 == level);
            return (levelDataTemplate != null) ? levelDataTemplate.Item2 : this._defaultLevelNodeDataTemplate;
        }
    }
}
