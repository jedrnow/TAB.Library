 export interface Rental {
    id: number
    fromUtc: string
    toUtc: string
    isReturned: boolean
    bookId: number
    bookTitle: string
    userId: number
    rentedBy: string
}
 
export interface RentalsResponse {
    list: Rental[]
    totalPages: number
}