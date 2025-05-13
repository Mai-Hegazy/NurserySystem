export function getEnumOptions<T extends object>(enumType: T): { value: any; label: string }[] {
    return Object.entries(enumType)
      .filter(([_, value]) => typeof value === 'string')
      .map(([key, value]) => ({ value, label: key }));
  }
  