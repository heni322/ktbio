import { Bell, ChevronDown, User, LogOut, Settings } from 'lucide-react';
import { Button } from '@/components/ui/button';
import {
  DropdownMenu,
  DropdownMenuContent,
  DropdownMenuItem,
  DropdownMenuSeparator,
  DropdownMenuTrigger,
} from '@/components/ui/dropdown-menu';
import { useNavigate } from 'react-router-dom';
import { useAuth } from '@/hooks/useAuth';

interface HeaderProps {
  notificationCount?: number;
}

export function Header({ notificationCount = 0 }: HeaderProps) {
  const { user, logout } = useAuth();
  const navigate = useNavigate();

  return (
    <header className="bg-[#3CBAAE] text-white h-16 flex items-center justify-between px-6 shadow-md">
      <div className="flex items-center">
        <h1 className="text-xl font-semibold">KT Bio</h1>
      </div>

      <div className="flex items-center gap-4">
        <div className="relative">
          <Button
            variant="ghost"
            size="icon"
            className="text-white hover:bg-[#35a89d] relative"
          >
            <Bell className="h-5 w-5" />
            {notificationCount > 0 && (
              <span className="absolute -top-1 -right-1 bg-red-500 text-white text-xs rounded-full h-5 w-5 flex items-center justify-center">
                {notificationCount}
              </span>
            )}
          </Button>
        </div>

        <DropdownMenu>
          <DropdownMenuTrigger asChild>
            <Button variant="ghost" className="text-white hover:bg-[#35a89d] flex items-center gap-2">
              <span className="hidden sm:inline">{user?.fullName || 'Anis Ben Khadija'}</span>
              <ChevronDown className="h-4 w-4" />
            </Button>
          </DropdownMenuTrigger>
          <DropdownMenuContent align="end" className="w-56">
            <div className="px-3 py-2">
              <p className="font-medium">{user?.fullName || 'Anis Ben Khadija'}</p>
              <p className="text-sm text-gray-500">{user?.email || 'anis@ktbio.tn'}</p>
            </div>
            <DropdownMenuSeparator />
            <DropdownMenuItem onClick={() => navigate('/profil')}>
              <User className="mr-2 h-4 w-4" />
              Profil
            </DropdownMenuItem>
            <DropdownMenuItem onClick={() => navigate('/parametres')}>
              <Settings className="mr-2 h-4 w-4" />
              Paramètres
            </DropdownMenuItem>
            <DropdownMenuSeparator />
            <DropdownMenuItem onClick={logout} className="text-red-600">
              <LogOut className="mr-2 h-4 w-4" />
              Déconnexion
            </DropdownMenuItem>
          </DropdownMenuContent>
        </DropdownMenu>
      </div>
    </header>
  );
}
