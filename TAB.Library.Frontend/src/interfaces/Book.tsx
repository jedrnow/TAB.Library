export interface BookDetail {
    id: number;
    title: string;
    publishYear: number;
    authorName: string;
    authorId: number;
    categoryId: number;
    categoryName: string;
    pdfContent: string;
    thumbnailSmallContent: string;
    thumbnailMediumContent: string;
    thumbnailLargeContent: string;
    isReserved: boolean;
}

export interface Book {
    id: number;
    title: string;
    publishYear: number;
    authorName: string;
    authorId: number;
    categoryId: number;
    categoryName: string;
    pdfContent: string;
    thumbnailMediumContent: string;
    isReserved: boolean;
}
  
export interface BooksResponse {
    list: Book[];
    totalPages: number;
}