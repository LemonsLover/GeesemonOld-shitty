import {gql} from '@apollo/client';

export const schema = gql`
    schema {
        query: Queries
        mutation: Mutations
        subscription: Subscriptions
    }

    type Queries {
        getUsers: [UserType]
    }

    type UserType {
        id: ID
        email: String
        chats: [ChatType]
        createdAt: DateTime
        updatedAt: DateTime
    }

    type ChatType {
        id: ID
        name: String
        createdAt: DateTime
        updatedAt: DateTime
    }

    """
    The \`DateTime\` scalar type represents a date and time. \`DateTime\` expects timestamps to be formatted in accordance with the [ISO-8601](https://en.wikipedia.org/wiki/ISO_8601) standard.
    """
    scalar DateTime

    type Mutations {
        createUser(
            """
            Argument for create new User
            """
            createUserInputType: CreateUserInputType
        ): UserType
    }

    input CreateUserInputType {
        """
        User Email
        """
        email: String
    }

    type Subscriptions {
        userAdded: UserType
    }

`
