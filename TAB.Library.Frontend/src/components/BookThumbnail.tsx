interface BookThumbnailProps {
    content: string;
  }

const BookThumbnail: React.FC<BookThumbnailProps> = ({ content }) => {
    if(!content || content.trim() === '') return;
    
    return (
        <>
            {content ? <img src={`data:image/jpeg;base64,${content}`} alt={`thumbnail`} /> : <p>Loading...</p>}
        </>
    );
};

export default BookThumbnail;
