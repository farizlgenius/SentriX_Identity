using System;

namespace Identity.Application.DTOs;

public sealed record LocationDto(string Name, string Description, int CountryId, string Country, int? Id = 0);