import React from "react";
import { AddBookRequest, BarebonesAuthor } from "../../../Clients/ApiClient"
import { AuthorSearchBar } from "./AuthorSearchBar";

interface SelectedAuthorProps {
    author: BarebonesAuthor;
    bookDetails: AddBookRequest;
    setBookDetails: (bookDetails: AddBookRequest) => void;
}

export const SelectedAuthor = (props : SelectedAuthorProps) => {

    const removeAuthor = (event: React.MouseEvent<HTMLButtonElement>) => {
        event.preventDefault()
        const newBookAuthors = props.bookDetails.bookAuthors.filter(a => a.authorID !== props.author.authorID)
        props.setBookDetails({ ...props.bookDetails, bookAuthors: newBookAuthors })
    }

    return (
        <div className="selected-author">
            <h4>{props.author.name}</h4>
            <button onClick={removeAuthor}>x</button>
        </div>
    )
}