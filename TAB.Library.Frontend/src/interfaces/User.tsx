export interface User {
    id: number
    username: string
    email: string
    firstName: string
    lastName: string
    phoneNumber: string
    role: string
    booksToReturn: number
}
 
export interface UsersResponse {
    list: User[]
    totalPages: number
}