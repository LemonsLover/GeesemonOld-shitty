export enum Role {
    User = 'USER',
    Admin = 'ADMIN',
}

export type User = {
    id: string,
    email: string,
    role: Role,
    createdAt: string,
    updatedAt: string,
}
