﻿using Crypto.API.Models.Dto;
using Crypto.API.Queries.GetCGTokens;

namespace Crypto.API.Services;

public class CoinGeckoService : ICoinGeckoService
{
    private readonly ICacheService _cacheService;

    public CoinGeckoService(ICacheService cacheService)
    {
        _cacheService = cacheService;
    }

    public async Task<IEnumerable<CryptoTokenDto>> GetCGTokensAsync(GetCGTokensQuery query)
    {
        var tokens = await _cacheService.GetCGTokensAsync();

        return tokens;
    }

    public async Task<PriceDataDto> GetPriceDataAsync(string tokenName, int days, CancellationToken cancellationToken)
    {
        var data = await _cacheService.GetPriceDataAsync(tokenName, days);

        return data;
    }

    public async Task<TokenDescriptionDto> GetTokenDescriptionAsync(string tokenName, CancellationToken cancellationToken)
    {
        var tokenDesc = await _cacheService.GetTokenDescriptionAsync(tokenName);

        return tokenDesc;
    }

    public async Task<GlobalDataDto> GetGlobalDataAsync(CancellationToken cancellationToken)
    {
        var data = await _cacheService.GetGlobalDataAsync();

        return data;
    }
}
