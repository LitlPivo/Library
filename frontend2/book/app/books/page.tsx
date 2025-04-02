"use client";
import Button  from "antd/es/button/button"
import {Books} from "../components/books"
import { useEffect, useState } from "react";
import { BookRequest, createBook, deleteBook, getAllBooks, updateBook } from "../Services/books";
import Title from "antd/es/typography/Title";
import { CreateUpdateBook, Mode } from "../components/CreateUpdateBook";


export default function BooksPage(){
    const defaultValues = {
        title:"",
        description:"",
        author:"",
        price: 1,
    } as Book;

    const [values,setValues] = useState<Book>(defaultValues);

    const [books,setBooks] = useState<Book[]>([]);
    const [loading,setLoading] = useState(true);
    const [isModalOpen,setIsModalOpen] = useState(false);
    const [mode,setMode] = useState(Mode.Create);

    useEffect(() => {
        const getBooks = async () => {
            const books = await getAllBooks();
            setLoading(false);
            setBooks(books);
        };

        getBooks();
    },[]);

    const hadleCreateBook = async (request:BookRequest) => {
        await createBook(request);
        closeModal();

        const books = await getAllBooks();
        setBooks(books);
    };

    const handleUpdateBook = async (id: string, request:BookRequest) =>{
        await updateBook(id,request);
        closeModal();

        const books = await getAllBooks();
        setBooks(books);
    };

    const handleDeleteBooks = async(id:string) => {
        await deleteBook(id);
        closeModal();

        const books = await getAllBooks();
        setBooks(books);
    };

    const openModal = () => {
        setMode(Mode.Create);
        setIsModalOpen(true);
    };

    const closeModal = () => {
        setValues(defaultValues);
        setIsModalOpen(false);
    };

    const openEditModal = (book : Book) => {
        setMode(Mode.Edit);
        setValues(book);
        setIsModalOpen(true);
    };

    return(
        <div>
            <Button
                type="primary"
                style={{marginTop:"30px"}}
                size="large"
                onClick={openModal}
            >
                Добавить книгу
            </Button>

            <CreateUpdateBook mode={mode} values={values} isModalOpen={isModalOpen} handleCreate={hadleCreateBook} handleUpdate={handleUpdateBook} handleCancel={closeModal}/>


            {loading ? <Title>Loading...</Title> : <Books books={books} handelOpen={openEditModal} handleDelete={handleDeleteBooks}/>}
        </div>
    )
}