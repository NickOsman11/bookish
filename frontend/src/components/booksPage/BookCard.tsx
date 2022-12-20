import { BarebonesAuthor } from "../../../Clients/ApiClient";

interface BookCardProps {
    bookID: number;
    title: string;
    coverImageURL?: string;
    descrpition?:string;
    authors: BarebonesAuthor[]
}

export const BookCard = (props: BookCardProps) => {
    return (
    <div className="bookCard">
        <h3>{props.title}</h3>
        <img src={props.coverImageURL} />
        <p>{props.descrpition}</p>
        <ul>
            {props.authors.map(a => {
                return <li>{a.name}</li>
            })}
        </ul>

    </div>
    )
}