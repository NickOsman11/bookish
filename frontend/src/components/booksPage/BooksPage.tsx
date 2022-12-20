import { ReactElement, useEffect, useState } from "react";
import { getAllBooks } from "../../../Clients/ApiClient"

interface BookResponse {
    bookID: number;
    title: string;
    authors?: any[];
}

export const BooksPage: React.FC  = () => {

    const [books, setBooks] = useState<BookResponse[]>()

    useEffect(() => {
        getAllBooks().then(response => setBooks(response))
    }, [])
    
    if (books === undefined) {
        return (<>loading...</>)
    }
    else {
        console.log(books)
        return (
            <>
                <ol>
                    {books.map(book => {
                        return <li> {book.title} </li>}
                    )}
                </ol>
            </>
        )
    }
}