const backendUrl = "https://localhost:7068"



interface BookResponse {
    bookID: number;
    title: string;
    authors: any[];
}

export interface BarebonesAuthor {
    id: number;
    name: string;
}

export const getAllBooks = async () : Promise<BookResponse[]> => {

    const response = await fetch(`${backendUrl}/books`).then(response => response.json())

    return response
}