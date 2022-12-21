const backendUrl = "https://localhost:7068"

export interface AddBookRequest {
    title: string;
    coverImageURL: string;
    description: string;
    bookAuthors: BarebonesAuthor[];
}

interface BookResponse {
    bookID: number;
    title: string;
    authors: any[];
}

export interface BarebonesAuthor {
    authorID: number;
    name: string;
}

export const getAllBarebonesAuthors = async () : Promise<BarebonesAuthor[]> => {

    const response = await fetch(`${backendUrl}/authors/bb`).then(response => response.json())
    return response
}

export const getAllBooks = async () : Promise<BookResponse[]> => {

    const response = await fetch(`${backendUrl}/books`).then(response => response.json())
    return response
}

export const addBook = async (request: AddBookRequest) : Promise<Boolean> => {
    
    try {
        console.log(request)
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