import { ReactSearchAutocomplete } from "react-search-autocomplete";
import { AddBookRequest, BarebonesAuthor } from "../../../Clients/ApiClient"
import { SelectedAuthor } from "./SelectedAuthor";

interface AuthorSearchBarProps {
    bookDetails: AddBookRequest;
    setBookDetails: (bookDetails: AddBookRequest) => void;
    allAuthors: BarebonesAuthor[];
}

export const AuthorSearchBar = (props : AuthorSearchBarProps) => {
    
    const handleOnSelect = (item: BarebonesAuthor) => {
        console.log(item)
        const newAuthors = [...props.bookDetails.bookAuthors]
        newAuthors.push(item)
        props.setBookDetails({ ...props.bookDetails, bookAuthors: newAuthors })
    }

    const formatResult = (item: any) => {
        return (
          <>
            <span className="search-result">
                {item.name}
            </span>
          </>
        )
    }

    return (
    <div className="select-authors-area"> 
        <div className="search-bar">  
            <ReactSearchAutocomplete
                items={props.allAuthors}
                onSelect={handleOnSelect}
                autoFocus
                formatResult={formatResult}
            />
        </div>
        <div className="selected-authors">
            {props.bookDetails.bookAuthors.map(author => {
                return (
                <SelectedAuthor
                    author={author}
                    bookDetails={props.bookDetails}
                    setBookDetails={props.setBookDetails}
                />
                )
            })}
        </div>
    </div>
        
    )        
}