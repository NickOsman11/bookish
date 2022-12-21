import { useState } from "react";
import { addBook, AddBookRequest, BarebonesAuthor } from "../../../Clients/ApiClient";
import { AuthorSearchBar } from "./AuthorSearchBar";

interface AddBookFormProps {
    allAuthors: BarebonesAuthor[];
}

export const AddBookForm = (props : AddBookFormProps) => {

    const [bookDetails, setBookDetails] = useState<AddBookRequest>(    
    {
        title: "",
        coverImageURL: "",
        description: "",
        bookAuthors: [],
    })

    const handleChange = (event: React.FormEvent<HTMLInputElement>) => {
        setBookDetails({ ...bookDetails, [event.currentTarget.name]: event.currentTarget.value });
    };

    const handleSubmit = (event: any) => {

        event.preventDefault();
        addBook(bookDetails).then(response => console.log(response))
    };

    return (

    <form onSubmit={handleSubmit}>
        <div>
            <input
                type="text"
                name="title"
                placeholder="Title"
                value={bookDetails.title}
                onChange={handleChange}
            />
        </div>
        <div>
            <input
                type="text"
                name="coverImageURL"
                placeholder="Cover Image URL"
                value={bookDetails.coverImageURL}
                onChange={handleChange}
            />
        </div>
        <div>
            <input
                type="text"
                name="description"
                placeholder="Description..."
                value={bookDetails.description}
                onChange={handleChange}
            />
        </div>
        <div>
            <AuthorSearchBar 
                bookDetails={bookDetails}
                setBookDetails={setBookDetails}
                allAuthors={props.allAuthors}
            />
        </div>
        <button type="submit">
            Submit
        </button>
    </form>
    )
}