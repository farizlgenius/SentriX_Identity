using System;

namespace Identity.Api.DTOs;

public sealed record LoginDto(string Username, string Password);
