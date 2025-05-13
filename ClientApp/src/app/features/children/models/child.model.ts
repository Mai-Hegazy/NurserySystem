export interface Child  {
    id: number;
    fullName: string;
    dateOfBirth?: string;
    allergies?: string;
    gender?: string; // Gender enum as string
    status?: string; // ChildStatus enum as string
    bloodType?: string; // BloodType enum as string
    address?: string;
    notes?: string;
}
