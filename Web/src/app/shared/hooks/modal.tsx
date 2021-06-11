import React, {
  useState,
  useImperativeHandle,
  forwardRef,
  useEffect,
  useCallback,
  RefObject,
} from 'react';
import { createPortal } from 'react-dom';

const modalElement: HTMLElement | null = document.getElementById('modal-root');

interface IProps {
  children: any;
  defaultOpen: boolean;
  ModalTitle: string;
}

export function Modal({ children, defaultOpen, ModalTitle }: IProps, ref: any) {
  const [isOpen, setIsOpen] = useState<boolean>(defaultOpen);

  const close = useCallback(() => setIsOpen(false), []);

  useImperativeHandle(
    ref,
    () => ({
      open: () => setIsOpen(true),
      close,
    }),
    [close]
  );

  const handleEscape = useCallback((event) => {
    if (event.keyCode === 27) setIsOpen(false);
  }, []);

  useEffect(() => {
    if (isOpen) document.addEventListener('keydown', handleEscape, false);
    return () => {
      document.removeEventListener('keydown', handleEscape, false);
    };
  }, [handleEscape, isOpen]);

  return modalElement
    ? createPortal(
        isOpen ? (
          <div className="flex items-center justify-center fixed left-0 bottom-0 w-full h-full ">
            <div className="rounded-lg w-1/2 bg-gray-100 shadow">
              <div className="flex flex-col items-start p-4">
                <div className="flex items-center w-full">
                  <div className="text-gray-900 font-medium text-lg">
                    {ModalTitle.toLocaleUpperCase()}
                  </div>
                  <svg
                    onClick={close}
                    className="ml-auto fill-current text-gray-700 w-6 h-6 cursor-pointer"
                    xmlns="http://www.w3.org/2000/svg"
                    viewBox="0 0 18 18"
                  >
                    <path d="M14.53 4.53l-1.06-1.06L9 7.94 4.53 3.47 3.47 4.53 7.94 9l-4.47 4.47 1.06 1.06L9 10.06l4.47 4.47 1.06-1.06L10.06 9z" />
                  </svg>
                </div>
                <br />
                <div>{children}</div>
                <br />
                <div className="ml-auto">
                  <button
                    onClick={close}
                    className="bg-transparent hover:bg-gray-500 text-blue-600 font-semibold hover:text-white py-2 px-4 border border-blue-600 hover:border-transparent rounded"
                  >
                    Close
                  </button>
                </div>
              </div>
            </div>
          </div>
        ) : // <div className="modal">
        //   <div className="bg-white rounded-lg w-1/2" onClick={close}>
        //     <div className="flex flex-col items-start p-4">
        //       <div className="flex items-center w-full">
        //         <div className="text-gray-900 font-medium text-lg">
        //           My modal title
        //         </div>
        //         <svg
        //           className="ml-auto fill-current text-gray-700 w-6 h-6 cursor-pointer"
        //           xmlns="http://www.w3.org/2000/svg"
        //           viewBox="0 0 18 18"
        //         >
        //           <path d="M14.53 4.53l-1.06-1.06L9 7.94 4.53 3.47 3.47 4.53 7.94 9l-4.47 4.47 1.06 1.06L9 10.06l4.47 4.47 1.06-1.06L10.06 9z" />
        //         </svg>
        //       </div>
        //       <hr />
        //       <div className="ml-auto">
        //         <div>{children}</div>
        //       </div>
        //     </div>
        //   </div>
        // </div>
        null,
        modalElement
      )
    : null;
}

export default forwardRef(Modal);
