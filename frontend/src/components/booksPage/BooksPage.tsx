import { ReactElement, useEffect, useState } from "react";
import { BarebonesAuthor, getAllBooks } from "../../../Clients/ApiClient"
import { BookCard } from "./BookCard";

interface BookResponse {
    bookID: number;
    title: string;
    authors: BarebonesAuthor[];
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
                        return (
                        <li>
                            <BookCard 
                                bookID={book.bookID}
                                title={book.title}
                                authors={book.authors}
                            /> 
                        </li>
                        )}
                    )}
                </ol>
            </>
        )
    }
}