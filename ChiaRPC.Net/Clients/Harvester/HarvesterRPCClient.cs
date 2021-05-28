using ChiaRPC.Models;
using ChiaRPC.Results;
using ChiaRPC.Routes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChiaRPC.Clients
{
    public sealed class HarvesterRPCClient : ChiaRPCClient
    {
        public HarvesterRPCClient(ChiaRPCOptions options, string apiUrl)
            : base(options, "harvester", apiUrl)
        {
        }

        /// <summary>
        /// Gets a list of plots being farmed on this harvester.
        /// </summary>
        /// <returns></returns>
        public async Task<Plot[]> GetPlotsAsync()
        {
            var result = await PostAsync<GetPlotsResult>(HarvesterRoutes.GetPlots());
            return result.Plots;
        }

        /// <summary>
        /// Refreshes the plots, forces the harvester to search for and load new plots.
        /// </summary>
        /// <returns></returns>
        public Task RefreshPlotsAsync()
            => PostAsync(HarvesterRoutes.RefreshPlots());

        /// <summary>
        /// Deletes a plot file and removes it from the harvester.
        /// </summary>
        /// <returns></returns>
        public Task DeletePlotAsync(string fileName)
            => PostAsync(HarvesterRoutes.DeletePlot(), new Dictionary<string, string>()
            {
                ["filename"] = fileName
            });

        /// <summary>
        /// Adds a plot directory (not including sub-directories) to the harvester and configuration. Plots will be loaded and farmed eventually.
        /// </summary>
        /// <returns></returns>
        public Task AddPlotDirectoryAsync(string dirPath)
            => PostAsync(HarvesterRoutes.AddPlotDirectory(), new Dictionary<string, string>()
            {
                ["dirname"] = dirPath
            });

        /// <summary>
        /// Returns all of the plot directoried being farmed.
        /// </summary>
        /// <returns></returns>
        public async Task<string[]> GetPlotDirectoriesAsync()
        {
            var result = await PostAsync<GetPlotDirectoriesResult>(HarvesterRoutes.GetPlotDirectories());
            return result.Directories;
        }

        /// <summary>
        /// Removes a plot directory from the config, does not actually delete the directory.
        /// </summary>
        /// <returns></returns>
        public Task RemovePlotDirectoryAsync(string dirPath)
            => PostAsync(HarvesterRoutes.RemovePlotDirectory(), new Dictionary<string, string>()
            {
                ["dirname"] = dirPath
            });
    }
}
