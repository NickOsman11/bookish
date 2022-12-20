import { useState } from 'react'
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import './App.css'
import { BooksPage } from './components/booksPage/BooksPage'

const SiteRoutes = () => {
    
    return (
        <Routes>
            <Route path="/books" element={<BooksPage />} />
            <Route path="/books/add" element={<p>Welcome to the AddBook page</p>} />
        </Routes>
    )
}


const App = () => {

    return (
        <Router>
            <div className="App">
                <h1>Hi Mum</h1>
                <SiteRoutes />
            </div>
        </Router>
    )
}

export default App
