using System;

namespace ChiaRPC.Routes
{
    internal static class FullNodeRoutes
    {
        public static Uri GetBlockchainState()
            => new Uri("get_blockchain_state", UriKind.Relative);

        public static Uri GetBlock()
            => new Uri("get_block", UriKind.Relative);

        public static Uri GetBlocks()
            => new Uri("get_blocks", UriKind.Relative);

        public static Uri GetRecentSignagePointOrEos()
            => new Uri("get_recent_signage_point_or_eos", UriKind.Relative);

        public static Uri GetPayToSingletonPuzzleHashFromLauncherId()
            => new Uri("get_p2_puzzle_hash_from_launcher_id", UriKind.Relative);

        public static Uri AggregateVerifySignature()
            => new Uri("aggregate_verify_signature", UriKind.Relative);

        public static Uri VerifySignature()
            => new Uri("verify_signature", UriKind.Relative);

        public static Uri GetProofQualityString()
            => new Uri("get_proof_quality_string", UriKind.Relative);

        public static Uri GetCoinRecordByName()
            => new Uri("get_coin_record_by_name", UriKind.Relative);

        public static Uri GetPuzzleAndSolution()
            => new Uri("get_puzzle_and_solution", UriKind.Relative);

        public static Uri GetDelayedPuzzleInfoFromLauncherSpend()
            => new Uri("get_delayed_puz_info_from_launcher_spend", UriKind.Relative);

        public static Uri GetSingletonState()
            => new Uri("get_singleton_state", UriKind.Relative);

        public static Uri GetPoolStateFromSingletonCoinSpend()
            => new Uri("get_pool_state_from_coin_spend", UriKind.Relative);
    }
}
