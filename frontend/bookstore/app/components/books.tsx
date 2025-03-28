import  Card  from "antd/es/card/Card"
import { CardTitle } from "./Cardtitle"
import Button  from "antd/es/button/button"


interface Props{
    books:Book[];
    handleDelete:(id:string)=>void;
    handelOpen:(book:Book)=>void;
}

export const Books = ({books,handleDelete,handelOpen}:Props) =>
     {
        return(
            <div className="cards">
                {books.map((book : Book)=> (
                    <Card key={book.id} title={<CardTitle title={book.title} price= {book.price}/>} bordered={false}>
                    <p>{book.description}</p>
                    <p>{book.author}</p>
                    <div className="card_buttons">
                        <Button onClick={() => handelOpen(book)} style={{flex: 1}}>Редактирвоать</Button>
                        <Button onClick={() => handleDelete(book.id)} danger style={{flex: 1}}>Удалить</Button>
                    </div>    
                    </Card>
                ))}
            </div>
        )
     }