using System;

namespace Identity.Application.DTOs;

public sealed record LoginDto(string Username, string Password);
