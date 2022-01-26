export type User = {
    id: number,
    email: string,
}

export type Auth = {
    user: User,
    accessToken: string,
}
