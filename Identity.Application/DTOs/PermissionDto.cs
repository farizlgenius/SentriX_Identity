using System;

namespace Identity.Application.DTOs;

public sealed record PermissionDto(int FeatureId, string FeatureName, bool IsEnabled, bool IsCreated, bool IsUpdated, bool IsDeleted);
