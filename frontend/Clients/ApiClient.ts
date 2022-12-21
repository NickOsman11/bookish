const backendUrl = "https://localhost:7068"

export interface AddBookRequest {
    title: string;
    coverImageURL: string;
    description: string;
    authorIDs: number[];
}

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

export const addBook = async (request: AddBookRequest) : Promise<Boolean> => {
    
    try {
        const response: Response = await fetch(`${backendUrl}/books/add`, {
            method: 'POST',
            body: JSON.stringify(request),
            headers: { 'Content-Type': 'application/json' }
        })

        return await response.ok
    }
    catch {

        return false
    }


}