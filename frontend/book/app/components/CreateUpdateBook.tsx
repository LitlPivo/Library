import Modal from "antd/es/modal/Modal";
import { BookRequest } from "../Services/books";
import Input from "antd/es/input/Input";
import { title } from "process";
import { useEffect, useState } from "react";
import TextArea from "antd/es/input/TextArea";

interface Props {
    mode: Mode;
    values: Book;
    isModalOpen: boolean;
    handleCancel: () => void;
    handleCreate: (request : BookRequest) => void;
    handleUpdate: (id:string, request : BookRequest) => void;
}

export enum Mode{
    Create,
    Edit,
}

export const CreateUpdateBook = ({
    mode,
    values,
    isModalOpen,
    handleCancel,
    handleCreate,
    handleUpdate,
}:Props) => {
const [title, setTitle] = useState<string>("");
const [description, setDescription] = useState<string>("");
const [author, setAuthor] = useState<string>("");
const [price, setPrice] = useState<number>(1);

useEffect(() => {
    setTitle(values.title);
    setDescription(values.description);
    setAuthor(values.author);
    setPrice(values.price);
}, [values]);

const handleOnOk = async () => {
    const bookRequest = {title,description,author, price};

    mode == Mode.Create ? handleCreate(bookRequest) : handleUpdate(values.id, bookRequest);
};

    return (
        <Modal title = {mode === Mode.Create ? "Добавить книгу" : "Редактировать книгу"}
        open={isModalOpen}
        onOk={handleOnOk}
        onCancel={handleCancel}
        cancelText={"Отмена"}
        >
            <div className="book_modal">
                <Input
                    value={title}
                    onChange={(e) => setTitle(e.target.value)}
                    placeholder="Название"
                />
                <TextArea
                value={description}
                onChange={(e) => setDescription(e.target.value)}
                autoSize={{minRows:3,maxRows:3}}
                placeholder="Описание"
                />
                <TextArea
                value={author}
                onChange={(e) => setAuthor(e.target.value)}
                autoSize={{minRows:3,maxRows:3}}
                placeholder="Автор"
                />
                <Input
                value={price}
                onChange={(e) => setPrice(Number(e.target.value))}
                placeholder="Цена"
                />
            </div>
        </Modal>
    );
};