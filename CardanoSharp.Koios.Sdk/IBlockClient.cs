﻿using System.Text.Json.Serialization;
using System.Threading.Tasks;
using CardanoSharp.Koios.Sdk.Contracts;
using Refit;

namespace CardanoSharp.Koios.Sdk
{
    public interface IBlockClient
    {
        [Get("/blocks")]
        Task<ApiResponse<Block[]>> GetBlockList([AliasAs("limit")]int? limit = null, 
            [AliasAs("offset")]int? offset = null, 
            [Header("Prefer")] string? prefer = null);
        
        [Post("/block_info")]
        Task<ApiResponse<Block[]>> GetBlockInfo([Body] BulkBlockRequest request, 
            [AliasAs("limit")]int? limit = null, 
            [AliasAs("offset")]int? offset = null, 
            [Header("Prefer")] string? prefer = null);
        
        [Post("/block_txs")]
        Task<ApiResponse<BlockTransaction[]>> GetBlockTransactions([Body] BulkBlockRequest request,
            [AliasAs("limit")]int? limit = null, 
            [AliasAs("offset")]int? offset = null, 
            [Header("Prefer")] string? prefer = null);
    }   
    
    public class BulkBlockRequest
    {
        [JsonPropertyName("_block_hashes")]
        public string[]? BlockHashes { get; set; }
    }
}