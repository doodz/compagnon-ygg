using System;
using Doods.StdFramework.Mvvm;

namespace CompagnonYgg.Core.Views.Home
{
    public class HomeMasterDetailPageMenuItem : IPageMenuItem

    {
        public HomeMasterDetailPageMenuItem()
        {
            TargetType = typeof(HomeMasterDetailPageDetail);
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
        public string Icon { get; set; }
    }
}