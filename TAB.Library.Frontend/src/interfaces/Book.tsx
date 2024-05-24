export interface Book {
    id: number;
    title: string;
    publishYear: number;
    authorName: string;
    authorId: number;
    categoryId: number;
    categoryName: string;
    pdfContent: string;
    isReserved: boolean;
}
  
export interface BooksResponse {
    list: Book[];
    totalPages: number;
}