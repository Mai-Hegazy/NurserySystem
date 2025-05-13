export enum ChildStatus {
  Active = "Active",
  Inactive = "Inactive",
  Graduated = "Graduated",
  Suspended = "Suspended"
}

export const ChildStatusLabel: Record<ChildStatus, string> = {
  [ChildStatus.Active]: 'Active',
  [ChildStatus.Inactive]: 'Inactive',
  [ChildStatus.Graduated]: 'Graduated',
  [ChildStatus.Suspended]: 'Suspended',
};