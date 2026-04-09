using System;

namespace Identity.Application.DTOs;

public sealed record LocationDto(int Id, string Name, string Description, int CountryId, string Country);