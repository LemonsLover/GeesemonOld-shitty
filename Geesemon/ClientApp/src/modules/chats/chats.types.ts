export enum ChatType {
    Dialog = 'Dialog',
    Group = 'Group',
}

export type Chat = {
    id: string,
    name: string,
    type: ChatType,
    createAt: string,
    updatedAt: string,
}
