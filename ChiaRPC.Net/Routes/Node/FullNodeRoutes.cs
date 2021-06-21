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
    }
}
