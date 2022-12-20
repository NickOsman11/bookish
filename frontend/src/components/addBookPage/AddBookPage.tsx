import { useState } from "react"
import { BarebonesAuthor } from "../../../Clients/ApiClient"

interface AddBookRequest {
    title: string;
    coverImageURL: string;
    description: string;
    authorIDs: number[];
}

export const AddBookPage = () => {

    const [authors, setAuthors] = useState<BarebonesAuthor[]>()
    const [bookDetails, setBookDetails] = useState<AddBookRequest>(
    {
        title: "",
        coverImageURL: "",
        description: "",
        authorIDs: [],
    })

    const handleChange = (event: React.FormEvent<HTMLInputElement>) => {

        if (event.currentTarget.name === "authorIDs") {
            const array = [parseInt(event.currentTarget.value)]
            setBookDetails({ ...bookDetails, [event.currentTarget.name]: array });
        }
        else {
            setBookDetails({ ...bookDetails, [event.currentTarget.name]: event.currentTarget.value });
        }
    };

    const handleSubmit = (event: any) => {
        event.preventDefault();
        console.log(bookDetails)
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
                <input
                    type="number"
                    name="authorIDs"
                    placeholder="Author IDs"
                    onChange={handleChange}
                />
            </div>
            <button type="submit">
                Submit
            </button>
        </form>
    )
}