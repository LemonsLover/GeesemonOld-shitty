import {gql} from '@apollo/client';

export const schema = gql`
    schema {
        query: Queries
        mutation: Mutations
        subscription: Subscriptions
    }

    type Queries {
        getUsers: [User]
        getMyChats: [Chat]
        isAuth: AuthResponseType
        getMessages(
            """
            Argument for get messages.
            """
            getMessagesInputType: GetMessagesInputType
        ): [Message]
    }

    type User {
        """
        User id.
        """
        id: ID

        """
        User Email.
        """
        email: String

        """
        User role.
        """
        role: RoleEnum

        """
        User creation date.
        """
        createdAt: DateTime

        """
        User update date.
        """
        updatedAt: DateTime
    }

    enum RoleEnum {
        USER
        ADMIN
    }

    """
    The \`DateTime\` scalar type represents a date and time. \`DateTime\` expects timestamps to be formatted in accordance with the [ISO-8601](https://en.wikipedia.org/wiki/ISO_8601) standard.
    """
    scalar DateTime

    type Chat {
        """
        Chat id.
        """
        id: ID

        """
        Chat name.
        """
        name: String

        """
        Chat Type.
        """
        type: Type

        """
        Chat creation date.
        """
        createAt: DateTime

        """
        Chat update date.
        """
        updatedAt: DateTime
    }

    enum Type {
        DIALOG
        GROUP
    }

    type AuthResponseType {
        """
        User type
        """
        user: User

        """
        Token type
        """
        token: String
    }

    type Message {
        """
        Message id.
        """
        id: ID

        """
        Message Text.
        """
        text: String

        """
        Message's chat id.
        """
        chatId: Int

        """
        Message's user id.
        """
        userId: Int

        """
        Message's creation date.
        """
        createdAt: DateTime

        """
        Message's update date.
        """
        updatedAt: DateTime
    }

    input GetMessagesInputType {
        """
        Message page number.
        """
        page: Int!

        """
        Message page size.
        """
        pageSize: Int!
    }

    type Mutations {
        createUser(
            """
            Argument for create new User
            """
            createUserInputType: CreateUserInputType
        ): User
        login(
            """
            Argument for login User
            """
            loginAuthInputType: LoginAuthInputType
        ): AuthResponseType
        createMessage(
            """
            Argument for create new Message
            """
            createMessageInputType: CreateMessageInputType
        ): Message
    }

    input CreateUserInputType {
        """
        User Email
        """
        email: String
    }

    input LoginAuthInputType {
        email: String
        password: String
    }

    input CreateMessageInputType {
        """
        Message Text.
        """
        text: String!
    }

    type Subscriptions {
        userAdded: User
        messageAdded: Message
    }
`
