import { useState } from 'react'
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import './App.css'
import { AddBookPage } from './components/addBookPage/AddBookPage';
import { BooksPage } from './components/booksPage/BooksPage'

const SiteRoutes = () => {

    return (
        <Routes>
            <Route path="/books" element={<BooksPage />} />
            <Route path="/books/add" element={<AddBookPage />} />
        </Routes>
    )
}


const App = () => {

    return (
        <Router>
            <div className="App">
                <h1>Bookish innit</h1>
                <SiteRoutes />
            </div>
        </Router>
    )
}

export default App
