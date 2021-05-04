using System;

namespace ChiaRPC.Routes
{
    internal static class HarvesterRoutes
    {
        public static Uri GetPlots()
            => new Uri("get_plots", UriKind.Relative);

        public static Uri RefreshPlots()
            => new Uri("refresh_plots", UriKind.Relative);

        public static Uri DeletePlot()
            => new Uri("delete_plot", UriKind.Relative);

        public static Uri AddPlotDirectory()
            => new Uri("add_plot_directory", UriKind.Relative);

        public static Uri GetPlotDirectories()
            => new Uri("get_plot_directories", UriKind.Relative);

        public static Uri RemovePlotDirectory()
            => new Uri("remove_plot_directory", UriKind.Relative);
    }
}
