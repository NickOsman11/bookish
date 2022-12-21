import { useEffect, useState } from "react"
import { addBook, AddBookRequest, BarebonesAuthor, getAllBarebonesAuthors } from "../../../Clients/ApiClient"
import { ReactSearchAutocomplete } from 'react-search-autocomplete'
import { Link } from "react-router-dom"
import { AddBookForm } from "./AddBookForm"
import { LoadingScreen } from "../loadingScreen/LoadingScreen"

export const AddBookPage = () => {

    const [allAuthors, setAllAuthors] = useState<BarebonesAuthor[]>()

    useEffect(() => {
        getAllBarebonesAuthors().then(response => setAllAuthors(response))
    }, [])

    if (allAuthors === undefined) {
        return <LoadingScreen />
    }
    return (
        <AddBookForm
            allAuthors={allAuthors}
        />
    )
}
